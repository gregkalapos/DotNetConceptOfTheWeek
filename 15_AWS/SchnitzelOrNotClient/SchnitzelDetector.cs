using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Lambda;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Util;

namespace SchnitzelOrNotClient
{
	public class SchnitzelDetector
	{
		String accesKey = "";
		String secretKey = "";

		public async Task<bool> IsSchnitzel(String filePath, String fileName)
		{
			await UploadToS3(filePath, fileName);

			AmazonLambdaClient alc = new AmazonLambdaClient(accesKey, secretKey, RegionEndpoint.EUCentral1);
			Amazon.Lambda.Model.InvokeRequest ir = new Amazon.Lambda.Model.InvokeRequest();
			ir.InvocationType = InvocationType.RequestResponse;
			ir.FunctionName = "SchnitzelOrNot";
		
			ir.Payload = "\"" + fileName + "\"";
			var res = await alc.InvokeAsync(ir);

			var strResponse = Encoding.ASCII.GetString(res.Payload.ToArray());

			if (bool.TryParse(strResponse, out bool retVal))
				return retVal;

			return false;
		}

		public async Task UploadToS3(String filePath, String fileName)
		{
			var client = new AmazonS3Client(accesKey, secretKey, Amazon.RegionEndpoint.USWest2);
			
			PutObjectRequest putRequest = new PutObjectRequest
			{
				BucketName = "sdffgdh3dfjkh342rhjvdf",
				Key = fileName,
				FilePath = filePath,
				ContentType = "text/plain"
			};
		
			PutObjectResponse response = await client.PutObjectAsync(putRequest);
		}

		private static byte[] ReadFully(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}
	}
}
