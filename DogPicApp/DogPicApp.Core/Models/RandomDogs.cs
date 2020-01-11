using Android.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using Bitmap = Android.Graphics.Bitmap;

namespace StarwarsApp.Core.Models
{
    public partial class RandomDogs
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
