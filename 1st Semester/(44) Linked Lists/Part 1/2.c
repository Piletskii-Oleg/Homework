struct node* second_element(struct node* head)
{
    if (head != NULL)
    {
        return head->next;
    }
    return 0;
}
