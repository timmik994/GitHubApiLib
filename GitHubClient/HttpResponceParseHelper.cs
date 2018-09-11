namespace GitHubClient
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// Helper class to parse HTTP response from git hub API.
    /// </summary>
    public class HttpResponceParseHelper
    {
        /// <summary>
        /// Processes HTTP response with json data from gitHub API.
        /// De-serializes data in object with <see cref="T"/> type.
        /// </summary>
        /// <typeparam name="T">Type of data in ClientResponse.</typeparam>
        /// <param name="responseMessage">The HTTP response message.</param>
        /// <param name="notFoundErrorMessage">The message shown if status code is NotFound.</param>
        /// <returns>ClientResponse instance with status and parsed data.</returns>
        public static async Task<ClientResponse<T>> ProcessHttpResponse<T>(
            HttpResponseMessage responseMessage,
            string notFoundErrorMessage)
        {
            ClientResponse<T> clientResponse = new ClientResponse<T>();
            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    clientResponse.Status = OperationStatus.Error;
                    clientResponse.Message = MessageConstants.Unauthorized;
                    break;
                case HttpStatusCode.NotFound:
                    clientResponse.Status = OperationStatus.NotFound;
                    clientResponse.Message = notFoundErrorMessage;
                    break;
                case HttpStatusCode.Created:
                    clientResponse.Status = OperationStatus.Susseess;
                    clientResponse.Message = MessageConstants.SuccessOperation;
                    break;
                case HttpStatusCode.OK:
                    string jsonString = await responseMessage.Content.ReadAsStringAsync();
                    try
                    {
                        clientResponse.Status = OperationStatus.Susseess;
                        clientResponse.Message = MessageConstants.SuccessOperation;
                        clientResponse.ResponseData = JsonConvert.DeserializeObject<T>(jsonString);
                    }
                    catch (Exception)
                    {
                        clientResponse.Message = string.Format(
                            CultureInfo.InvariantCulture,
                            MessageConstants.InvalidJsonErrorTemplate,
                            MessageConstants.InvalidJson,
                            jsonString);
                        clientResponse.Status = OperationStatus.Error;
                    }

                    break;
                default:
                    clientResponse.Status = OperationStatus.UnknownState;
                    clientResponse.Message = MessageConstants.UnknownError;
                    break;
            }

            return clientResponse;
        }
    }
}
