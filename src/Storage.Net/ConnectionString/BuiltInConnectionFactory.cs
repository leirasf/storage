﻿using System;
using System.Collections.Generic;
using System.IO;
using Storage.Net.Blobs;
using Storage.Net.Blobs.Files;
using Storage.Net.KeyValue;
using Storage.Net.KeyValue.Files;
using Storage.Net.Messaging;
using Storage.Net.Messaging.Files;

namespace Storage.Net.ConnectionString
{
   class BuiltInConnectionFactory : IConnectionFactory
   {
      public IBlobStorage CreateBlobStorage(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == "disk")
         {
            connectionString.GetRequired("path", true, out string path);

            return new DiskDirectoryBlobStorage(path);
         }

         if(connectionString.Prefix == "inmemory")
         {
            return new InMemoryBlobStorage();
         }

         if(connectionString.Prefix == "zip")
         {
            connectionString.GetRequired("path", true, out string path);

            return new ZipFileBlobStorage(path);
         }

         return null;
      }

      public IKeyValueStorage CreateKeyValueStorage(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == "disk")
         {
            connectionString.GetRequired("path", true, out string path);

            return new CsvFileKeyValueStorage(new DirectoryInfo(path));
         }

         return null;
      }

      public IMessagePublisher CreateMessagePublisher(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == "inmemory")
         {
            connectionString.GetRequired("name", true, out string name);

            return InMemoryMessagePublisherReceiver.CreateOrGet(name);
         }

         if(connectionString.Prefix == "disk")
         {
            connectionString.GetRequired("path", true, out string path);

            return new DiskMessagePublisherReceiver(path);
         }

         return null;
      }

      public IMessageReceiver CreateMessageReceiver(StorageConnectionString connectionString)
      {
         if(connectionString.Prefix == "inmemory")
         {
            connectionString.GetRequired("name", true, out string name);

            return InMemoryMessagePublisherReceiver.CreateOrGet(name);
         }

         if(connectionString.Prefix == "disk")
         {
            connectionString.GetRequired("path", true, out string path);

            return new DiskMessagePublisherReceiver(path);
         }


         return null;
      }
   }
}
