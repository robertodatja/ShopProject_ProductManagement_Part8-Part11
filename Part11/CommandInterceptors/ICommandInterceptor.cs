namespace Part11.CommandInterceptors
{
    public interface ICommandInterceptor
    {
        public string Operation { get;} //prop per veprimin
        void Execute(Command command); //metode qe do te ekzekuton interceptorin
        void ShowDoc(); //metode qe do te shfaq dokumentacionin
    }
}
