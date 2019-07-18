using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Plivo.Client;
using Plivo.Exception;

namespace Plivo.Http
{
    /// <summary>
    /// Plivo response.
    /// </summary>
    public class PlivoResponse<T>
    {
        /// <summary>
        /// The status code.
        /// </summary>
        public uint StatusCode;

        /// <summary>
        /// The headers.
        /// </summary>
        public List<string> Headers;

        /// <summary>
        /// The content.
        /// </summary>
        public string Content;

        /// <summary>
        /// The object.
        /// </summary>
        public T Object;

        /// <summary>
        /// The Plivo rest request.
        /// </summary>
        public PlivoRequest PlivoRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Http.PlivoResponse`1"/> class.
        /// </summary>
        public PlivoResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Http.PlivoResponse`1"/> class.
        /// </summary>
        /// <param name="statusCode">Status code.</param>
        /// <param name="headers">Headers.</param>
        /// <param name="content">Content.</param>
        /// <param name="obj">Object.</param>
        /// <param name="request">Request.</param>
        public PlivoResponse(uint statusCode, List<string> headers, string content, T obj, PlivoRequest request)
        {
            StatusCode = statusCode;
            Headers = headers;
            Content = content;
            Object = obj;
            PlivoRequest = request;


            HandleResponse();
        }

        /// <summary>
        /// Handles the response.
        /// </summary>
        private void HandleResponse()
        {
            // check status code
            if (!(StatusCode < 400))
            {
                // try to get error message from the contents
                ThrowException(GetErrorMessage());
            }
        }

        /// <summary>
        /// Throws the exception.
        /// </summary>
        /// <param name="message">Message.</param>
        private void ThrowException(string message)
        {
            switch (StatusCode)
            {
                case 400:
                    throw new PlivoValidationException(message);
                case 401:
                    throw new PlivoAuthenticationException(message);
                case 404:
                    throw new PlivoNotFoundException(message);
                case 405:
                    throw new PlivoRequestException(message);
                case 500:
                    throw new PlivoServerException(message);
                default:
                    throw new PlivoRestException(message, StatusCode);
            }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns>The error message.</returns>
        private string GetErrorMessage()
        {
            return Content;
        }
    }
}