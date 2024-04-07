using Part11.CommandInterceptors;

namespace Part11
{
    public static class InterceptorStore
    {
        public static List<ICommandInterceptor> interceptors = new List<ICommandInterceptor>()
        {
            new AddCommandInterceptor(),  //I. at PART2 PART3
            new ListCommandInterceptor(),      //II. at PART4
            new ListAllCommandInterceptor(),   //III.at PART5 
            new ClearCmdCommandInterceptor(),   //IV.at PART6
            new DeleteCommandInterceptor(),     //V. at PART6
            new UpdateCommandInterceptor(),    //VI. at PART6
            new CheckCommandInterceptor(),     //VII.at PART7
            new CalculateCommandInterceptor(),//VIII.at PART7
            new RemoveCommandInterceptor(),    //IX. at PART8
            new PrintCommandInterceptor(),      //X. at PART8
            new SaveCommandInterceptor(),      //XI. at Part9
            new BuyCommandInterceptor(),      //XII. at Part11
        };
    }
}
