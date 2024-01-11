using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Plivo.Client;
namespace Plivo.Resource.Media
{
    /// <summary>
    /// Media interface.
    /// </summary>
    public class MediaInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Media.MediaInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public MediaInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Media/";
        }

        #region upload
        /// <summary>
        /// Upload Media .
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="filename">FileName.</param>
        public MediaResponse Upload(string[] filePath)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                });
            var filesToUpload = new Dictionary<string, string>();
            for (int i = 0; i < filePath.Length; i++)
            {
                filesToUpload.Add("file" + i.ToString(), filePath[i]);
            }

            var result = Task.Run(async () => await Client.Update<MediaResponse>(Uri, data, filesToUpload).ConfigureAwait(false)).Result;
            // result.Object.StatusCode = result.StatusCode;
            // return result.
            return result.Object;
        }

        /// <summary>
        /// Asynchronously upload Media.
        /// </summary>
        /// <returns>The post.</returns>
        /// <param name="filename">filename ID.</param>
        public async Task<MediaUploadResponse> UploadAsync(string[] filePath)
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                });
            var filesToUpload = new Dictionary<string, string>();
            for (int i = 0; i < filePath.Length; i++)
            {
                filesToUpload.Add("file", filePath[i]);
            }
            var result = await Client.Update<MediaUploadResponse>(Uri, data, filesToUpload);
            result.Object.StatusCode = result.StatusCode;
            return result.Object;
        }
        #endregion




        #region Get
        /// <summary>
        /// Get Media with the specified mediaId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="media_id">Media Id.</param>
        public Media Get(string mediaId)
        {
            return ExecuteWithExceptionUnwrap(() =>
            {
                var media = Task.Run(async () => await GetResource<Media>(mediaId).ConfigureAwait(false)).Result;
                media.Interface = this;
                return media;
            });
        }
        /// <summary>
        /// Asynchronously get Media with the specified mediaID.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="mediaID">Media ID.</param>
        public async Task<Media> GetAsync(string mediaID)
        {
            var media = await GetResource<Media>(mediaID);
            media.Interface = this;
            return media;
        }
        #endregion



        #region List
        /// <summary>
        /// List Media with the specified limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>

        public ListResponse<Media> List(
            uint? limit = null,
            uint? offset = null
            )
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset
                });

            return ExecuteWithExceptionUnwrap(() =>
            {
                var resources = Task.Run(async () => await ListResources<ListResponse<Media>>(data).ConfigureAwait(false)).Result;
                resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
                resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
                resources.Objects.ForEach(
                    (obj) => obj.Interface = this
                );
                return resources;
            });
        }
        /// <summary>
        /// List Media with the specified  limit and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Media>> ListAsync(
            uint? limit = null,
            uint? offset = null
            )
        {
            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams, new
                {
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Media>>(data);
            resources.Meta.Previous = string.IsNullOrEmpty(resources.Meta.Previous) ? "null" : resources.Meta.Previous;
            resources.Meta.Next = string.IsNullOrEmpty(resources.Meta.Next) ? "null" : resources.Meta.Next;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion
    }
}