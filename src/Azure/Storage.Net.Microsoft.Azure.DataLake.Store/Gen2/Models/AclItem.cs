﻿namespace Storage.Net.Microsoft.Azure.DataLake.Store.Gen2.Models
{
   public class AclItem
   {
      public string User { get; set; }
      public AclPermission Access { get; set; }
      public AclPermission Default { get; set; }
   }
}
