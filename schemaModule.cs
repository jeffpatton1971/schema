using System;
using System.Net;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using schema.core;

namespace schema.module
{
 [Cmdlet(VerbsCommon.Get, "Schema")]
 public class GetSchema : PSCmdlet
 {
  [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ParameterSetName = "File")]
  public string Path { get; set; }
  [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ParameterSetName = "Url")]
  public string Uri { get; set; }
  protected override void ProcessRecord()
  {
   switch (ParameterSetName)
   {
    case "File":
     break;
    case "Uri":
     break;
   }
  }
 }
}