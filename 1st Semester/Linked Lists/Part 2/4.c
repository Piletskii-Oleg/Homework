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