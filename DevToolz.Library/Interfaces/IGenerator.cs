namespace DevToolz.Library.Interfaces;

public interface IGenerator
{
    string Generate();
    string Generate( bool masked );
}