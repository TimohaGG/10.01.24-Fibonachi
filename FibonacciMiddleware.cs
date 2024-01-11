namespace _10._01._24___Fibonachi
{
    public class FibonacciMiddleware
    {
        private readonly RequestDelegate next;

        public FibonacciMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string token = context.Request.Query["token"].ToString();
            var index = Convert.ToInt32(context.Request.Query["index"]);

            if (index < 0 || index > 40)
            {
                await context.Response.WriteAsync("Wrong index!");
                return;
            }
            if (token == "")
            {
                await context.Response.WriteAsync("No token!");
                return;
            }
            List<int> numbers = new List<int>();
            for ( var i = 0; i < index+1;i++ )
            {
                if (i <= 1)
                {
                    numbers.Add(i);
                }
                else
                {
                    numbers.Add(numbers[i-1] + numbers[i-2]);
                }
            }
            
            await context.Response.WriteAsync($"Hi, {token}. Number with index {index} is {numbers.Last().ToString()}");
           
        }
    }
}
