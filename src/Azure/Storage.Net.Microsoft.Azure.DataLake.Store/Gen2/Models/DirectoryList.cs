﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Storage.Net.Microsoft.Azure.DataLake.Store.Gen2.Models
{
   public class DirectoryList
   {
      [JsonProperty("paths")] public List<DirectoryItem> Paths { get; set; }
   }
}