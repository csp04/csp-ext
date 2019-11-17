using System;
using RSG;

namespace Csp.Extensions
{
    public static partial class RSGExtensions
    {

        public static IPromise AsyncInvokeAsPromise(this Action @this)
        {
            var p = new Promise();
            try
            {
                @this.BeginInvoke(ar =>
               {
                   try
                   {
                       @this.EndInvoke(ar);
                       p.Resolve();
                   }
                   catch (Exception ex)
                   {
                       p.Reject(ex);
                   }
               }, null);
            }
            catch (Exception ex)
            {
                p.Reject(ex);
            }

            return p;
        }

        public static IPromise<T> AsyncInvokeAsPromise<T>(this Func<T> @this)
        {
            var p = new Promise<T>();

            try
            {
                @this.BeginInvoke(ar =>
                {
                    try
                    {
                        var value = @this.EndInvoke(ar);
                        p.Resolve(value);
                    }
                    catch (Exception ex)
                    {
                        p.Reject(ex);
                    }
                }, null);
            }
            catch (Exception ex)
            {
                p.Reject(ex);
            }

            return p;
        }

        
    }
}
