void add_element(struct node* head, int value, int position)
{
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));

    if (position == 0)
    {
        newNode->value = value;
        newNode->next = head;
        head = newNode;
    }
    else
    {
        struct node* p = head;
        for (int i = 0; i < position - 1; i++)
        {
            if (p->next != NULL)
                p = p->next;
        }
        newNode->value = value;
        newNode->next = p->next;
        p->next = newNode;
    }
}

void add_another_element(struct node** headRef, int value, int position)
{
    struct node* p;
    p = (struct node*)malloc(sizeof(struct node));
    p->value = value;

    struct node* new = *headRef;

    for (int i = 0; i < position; i++)
    {
        if (new->next != NULL)
            new = new->next;
    }

    p->next = new->next;
    new->next = p;
}