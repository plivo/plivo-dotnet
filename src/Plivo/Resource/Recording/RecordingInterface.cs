using System;
using System.Linq;
using System.Reflection;
using Plivo.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plivo.Resource.Recording
{
    /// <summary>
    /// Recording interface.
    /// </summary>
    public class RecordingInterface : ResourceInterface
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:plivo.Resource.Recording.RecordingInterface"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        public RecordingInterface(HttpClient client) : base(client)
        {
            Uri = "Account/" + Client.GetAuthId() + "/Recording/";
        }

        #region Get
        /// <summary>
        /// Get Recording with the specified recordingId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        public Recording Get(string recordingId)
        {
            var recording = Task.Run(async () => await GetResource<Recording>(recordingId).ConfigureAwait(false)).Result;
            recording.Interface = this;
            return recording;
        }
        /// <summary>
        /// Asynchronously get Recording with the specified recordingId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        public async Task<Recording> GetAsync(string recordingId)
        {
            var recording = await GetResource<Recording>(recordingId);
            recording.Interface = this;
            return recording;
        }
        #endregion

        #region List
        /// <summary>
        /// List Recording with the specified subaccount, callUuid, addTime, addTime_Gt, addTime_Gte, addTime_Lt, addTime_Lte, limit
        /// and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="addTime">Add time.</param>
        /// <param name="addTime_Gt">Add time gt.</param>
        /// <param name="addTime_Gte">Add time gte.</param>
        /// <param name="addTime_Lt">Add time lt.</param>
        /// <param name="addTime_Lte">Add time lte.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public ListResponse<Recording> List(
            string subaccount = null, string callUuid = null,
            DateTime? addTime = null, DateTime? addTime_Gt = null,
            DateTime? addTime_Gte = null, DateTime? addTime_Lt = null,
            DateTime? addTime_Lte = null, uint? limit = null,
            uint? offset = null)
        {
            var _addTime = addTime?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gt = addTime_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gte = addTime_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lt = addTime_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lte = addTime_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var mandatoryParams = new List<string> {""};
            var data = CreateData(
                mandatoryParams,
                new
                {
                    subaccount,
                    callUuid,
                    _addTime,
                    _addTime_Gt,
                    _addTime_Gte,
                    _addTime_Lt,
                    _addTime_Lte,
                    limit,
                    offset
                });
            var resources = Task.Run(async () => await ListResources<ListResponse<Recording>>(data).ConfigureAwait(false)).Result;
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        /// <summary>
        /// List Recording with the specified subaccount, callUuid, addTime, addTime_Gt, addTime_Gte, addTime_Lt, addTime_Lte, limit
        /// and offset.
        /// </summary>
        /// <returns>The list.</returns>
        /// <param name="subaccount">Subaccount.</param>
        /// <param name="callUuid">Call UUID.</param>
        /// <param name="addTime">Add time.</param>
        /// <param name="addTime_Gt">Add time gt.</param>
        /// <param name="addTime_Gte">Add time gte.</param>
        /// <param name="addTime_Lt">Add time lt.</param>
        /// <param name="addTime_Lte">Add time lte.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="offset">Offset.</param>
        public async Task<ListResponse<Recording>> ListAsync(
            string subaccount = null, string callUuid = null,
            DateTime? addTime = null, DateTime? addTime_Gt = null,
            DateTime? addTime_Gte = null, DateTime? addTime_Lt = null,
            DateTime? addTime_Lte = null, uint? limit = null,
            uint? offset = null)
        {
            var _addTime = addTime?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gt = addTime_Gt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Gte = addTime_Gte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lt = addTime_Lt?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;
            var _addTime_Lte = addTime_Lte?.ToString("yyyy-MM-dd HH':'mm':'ss'.'ffffff''") ?? null;

            var mandatoryParams = new List<string> { "" };
            var data = CreateData(
                mandatoryParams,
                new
                {
                    subaccount,
                    callUuid,
                    _addTime,
                    _addTime_Gt,
                    _addTime_Gte,
                    _addTime_Lt,
                    _addTime_Lte,
                    limit,
                    offset
                });
            var resources = await ListResources<ListResponse<Recording>>(data);
            resources.Objects.ForEach(
                (obj) => obj.Interface = this
            );

            return resources;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Recording with the specified recordingId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        public DeleteResponse<Recording> Delete(string recordingId)
        {
            return Task.Run(async () => await DeleteResource<DeleteResponse<Recording>>(recordingId).ConfigureAwait(false)).Result;
        }

        /// <summary>
        /// Asynchronously delete Recording with the specified recordingId.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="recordingId">Recording identifier.</param>
        public async Task<DeleteResponse<Recording>> DeleteAsync(string recordingId)
        {
            return await DeleteResource<DeleteResponse<Recording>>(recordingId);
        }
        #endregion
    }
}