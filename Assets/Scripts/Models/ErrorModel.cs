using System.Collections;
using System.Collections.Generic;

public static class ErrorModel
{
     public static string IpValid {get;set;}
     public static string LoginValid {get;set;}

     public static bool isValid(){
          if(IpValid == null && LoginValid == null){
               return true;
          }
          else{
               return false;
          }
     }
}
