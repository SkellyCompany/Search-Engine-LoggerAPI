using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;

namespace SearchEngine.LoggerAPI.Core.Domain.Entity
{
    public class Log
    {
        public enum LogType
        {
            SUCCESS, WARNING, INFO, ERROR
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public LogType Type { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }

        [BsonElement("parameters")]
        public Dictionary<string, string> Parameters { get; set; }

    }
}