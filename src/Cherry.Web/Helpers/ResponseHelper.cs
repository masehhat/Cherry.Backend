using Cherry.Application.Common.Structures;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cherry.Web.Helpers
{
    public static class ResponseHelper
    {
        public static ObjectResult Created(this object data)
        {
            ResponseStructure objectData = new ResponseStructure
            {
                Data = data,
                Message = "OK"
            };

            return new ObjectResult(objectData)
            {
                StatusCode = 201
            };
        }

        public static ObjectResult AsActionResult(this object data)
        {
            ResponseStructure objectData = new ResponseStructure
            {
                Data = data,
                Message = "OK"
            };

            return new ObjectResult(objectData)
            {
                StatusCode = 200
            };
        }

        public static ObjectResult AsActionResult(this object data, string message)
        {
            ResponseStructure objectData = new ResponseStructure
            {
                Data = data,
                Message = message
            };

            return new ObjectResult(objectData)
            {
                StatusCode = 200
            };
        }

        public static ObjectResult AsActionResult(this object data, string message, HttpStatusCode statusCode)
        {
            ResponseStructure objectData = new ResponseStructure
            {
                Data = data,
                Message = message
            };

            return new ObjectResult(objectData)
            {
                StatusCode = (int)statusCode
            };
        }

        public static TResult ToSpecificResponseType<TResult>(this IActionResult actionResult)
        {
            ObjectResult objectResult = actionResult as ObjectResult;
            ResponseStructure data = objectResult.Value as ResponseStructure;
            TResult result = (TResult)data.Data;
            return result;
        }
    }
}