int main()
{
    int a;
    void* p = &a;
    printf("%p\n", p);

    int i = (int)p;
    void *newp = i * i + 3 * i + 1;
    printf("%p", newp);
    return EXIT_SUCCESS;
}