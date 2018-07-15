using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.S3;
using Amazon.S3.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SchnitzelOrNotLambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> FunctionHandler(string fileName, ILambdaContext context)
        {
			var accesKey = "";
			var secretKey = "";

			var rekognitionClient = new AmazonRekognitionClient(accesKey, secretKey, Amazon.RegionEndpoint.USWest2);

			var detectResponses = await rekognitionClient.DetectLabelsAsync(new DetectLabelsRequest
			{
				MinConfidence = 30,
				Image = new Image
				{
					S3Object = new Amazon.Rekognition.Model.S3Object
					{
						Bucket = "schnitzelornot",
						Name = fileName
					}
				}
			});

			foreach (var label in detectResponses.Labels)
			{
				if (label.Name == "Fried Chicken" || label.Name == "Nuggets")
					return true;
			}

			return false; ;
        }
    }
}
