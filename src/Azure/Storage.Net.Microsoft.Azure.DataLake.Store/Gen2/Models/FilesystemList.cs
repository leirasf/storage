﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Storage.Net.Microsoft.Azure.DataLake.Store.Gen2.Models
{
   public class FilesystemList
   {
      [JsonProperty("filesystems")]
      public List<FilesystemItem> Filesystems { get; set; }
   }
}
