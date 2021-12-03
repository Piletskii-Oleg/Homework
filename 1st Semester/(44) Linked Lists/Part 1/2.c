struct node* second_element(struct node* head)
{
    struct node* p = head;

    if (p != NULL)
        p = p->next;

    return p;
}                             