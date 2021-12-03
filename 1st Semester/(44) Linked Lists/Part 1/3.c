struct node* last_element(struct node* head)
{
    struct node* p = head;

    if (p == NULL)
        return p;

    while (p->next != NULL)
    {
        p = p->next;
    }
    return p;
}