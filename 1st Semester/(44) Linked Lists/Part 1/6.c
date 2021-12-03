int count_elements(struct node* head, _Bool (*f)(int))
{
    struct node* p = head;
    int count = 0;

    while (p != NULL)
    {
        if (f(p->value))
            count++;
        p = p->next;
    }
    return count;
}