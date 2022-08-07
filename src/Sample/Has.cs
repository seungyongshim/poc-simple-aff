namespace Sample;

public interface Has<out Service>
{
    Service Get();
}
