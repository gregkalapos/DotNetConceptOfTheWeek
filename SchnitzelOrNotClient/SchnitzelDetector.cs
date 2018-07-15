using System;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.S3;
using Amazon.S3.Model;

namespace SchnitzelOrNotClient
{
	public class SchnitzelDetector
	{
		private readonly string accessKey;
		private readonly string secretKey;

		public SchnitzelDetector(string accessKey, string secretKey)
		{
			this.accessKey = accessKey;
			this.secretKey = secretKey;
		}

		public async Task<Boolean> IsSchnitzel(string filePath, string fileName)
		{
			await UploadToS3(filePath, fileName);

			AmazonLambdaClient amazonLambdaClient 
				= new AmazonLambdaClient(accessKey, secretKey, Amazon.RegionEndpoint.EUWest1);

			InvokeRequest ir = new InvokeRequest();
			ir.InvocationType = InvocationType.RequestResponse;
			ir.FunctionName = "SchnitzelOrNot";

			ir.Payload = "\"" + fileName + "\"";

			var result = await amazonLambdaClient.InvokeAsync(ir);

			var strResponse = Encoding.ASCII.GetString(result.Payload.ToArray());

			if(bool.TryParse(strResponse, out bool retVal))
			{
				return retVal;
			}

			return false;
		}

		private async Task UploadToS3(string filePath, string fileName)
		{
			var client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.EUWest1);

			var putRequest = new PutObjectRequest
			{
				BucketName = "schnitzelornot",
				Key = fileName,
				FilePath = filePath,
				ContentType = "text/plain"
			};

			PutObjectResponse response = await client.PutObjectAsync(putRequest);
		}
	}
}
