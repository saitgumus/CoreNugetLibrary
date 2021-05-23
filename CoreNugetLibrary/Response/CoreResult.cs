using System;
using Microsoft.AspNetCore.Mvc;

namespace SG.Kernel.Response
{
    public class CoreResult<T> : ObjectResult
    {
        public Response<T> Response { get; private set; }

        public CoreResult():base(null)
        {
            Response = new Response<T>();
            this.StatusCode = 200;
        }

        public CoreResult(T value):base(value)
        {
            Response = new Response<T>();
            this.StatusCode = 200;
            Response.Value = value;
        }

        public CoreResult(Response<T> value) : base(value)
        {
            Response = new Response<T>();
            Response = value;
            if (Response.Success)
                this.StatusCode = 200;
            else
                this.StatusCode = 400;
        }

        public void SetErrorMessage(string message,int status = 400)
        {
            if(Response == null)
            {
                Response = new Response<T>();
            }
            Response.AddResults(new Result()
            {
                ErrorMessage = message
            });
            this.StatusCode = status;
            this.Value = Response;
        }

        public void SetValue(T value, int status = 200)
        {
            if (Response == null)
            {
                Response = new Response<T>();
            }

            Response.Value = value;
            this.StatusCode = status;
            this.Value = Response;
        }

        public void SetResponse(Response<T> response)
        {
            Response = response;
            this.Value = Response;
            this.StatusCode = 200;
        }
    }
}
