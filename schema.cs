using System;
using System.Net;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.PowerShell.Commands;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace schema
{
 [Cmdlet(VerbsCommon.Get, "Schema")]
 public class GetSchema : Cmdlet
 {
  [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
  public string Path { get; set; }

  protected override void ProcessRecord()
  {
   base.ProcessRecord();
    ErrorRecord errRec;
   if (Path.StartsWith("http:") || Path.StartsWith("https:"))
   {
       WebRequest request = WebRequest.Create(Path);
       WebResponse response = request.GetResponse();
       Stream dataStream = response.GetResponseStream();
       StreamReader reader = new StreamReader(dataStream);
       WriteObject((JsonObject.ConvertFromJson(reader.ReadToEnd(), out errRec)));
   }
   else
   {
    string jsonFile = File.ReadAllText(Path);
    WriteObject(JsonObject.ConvertFromJson(jsonFile, out errRec));
   }
  }
 }
}