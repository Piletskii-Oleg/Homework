void add_last(struct node** headRef, int d)
{
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));

    struct node* last = *headRef;
    newNode->next = NULL;
    newNode->value = d;

    if (*headRef == NULL)
    {
        *headRef = newNode;
        return;
    }
    while (last->next != NULL)
        last = last->next;

    last->next = newNode;
}

struct node* create_node()
{
    int value = 1;
    struct node** headRef = (struct node**)malloc(sizeof(struct node));
    *headRef = NULL;

    printf("0 is the last element of the List");
    while (value != 0)
    {
        scanf("%d", &value);
        add_last(headRef, value);
    }

    return *headRef;
}
