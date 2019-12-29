﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data
{
    public class Attachment
    {

        public Attachment(string filename, object content=null)
        {
            Filename = filename;
            Content = content;
            Type = AttachmentType.Text;
        }
        public enum AttachmentType
        {
            Json, Text, 
        }

        public string Filename { get; set; }
        public object Content { get; set; }
        public AttachmentType Type { get; set; }

        public async Task<MemoryStream> ContentToStreamAsync()
        {
            string text;
            switch (Type)
            {
                case AttachmentType.Json :
                    text = Newtonsoft.Json.JsonConvert.SerializeObject(Content);
                    break;
                case AttachmentType.Text:
                    text = Content.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
             //write the content to memory stream
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8);
            await writer.WriteAsync(text);
            await writer.FlushAsync();
            stream.Position = 0;
            return stream;
        }

    }
}
