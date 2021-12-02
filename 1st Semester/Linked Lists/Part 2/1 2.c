void add_first(struct node** head, int d)
{
    struct node* p;
    p = (struct node*)malloc(sizeof(struct node));
    p->value = d;
    p->next = *head;
    *head = p;
}


#define ADD_FIRST(TYPE)                                           \
void add_first_##TYPE(struct node_##TYPE** f, TYPE d)             \
{                                                                 \
    struct node* p;                                               \
    p = (struct node_##TYPE*)malloc(sizeof(struct node_##TYPE));  \
    p->value = d;                                                 \
    p->next = *f;                                                 \
    *f = p;                                                       \
}                                                                 \

void add_last(struct node** headRef, int d)
{
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));

    struct node* last = *headRef;
    newNode->value = d;

    if (*headRef == NULL)
    {
        *headRef = newNode;
        return;
    }
    while (last->next != NULL)
        last = last->next;

    last->next = newNode;
    newNode->next = NULL;
}

#define ADD_LAST(TYPE)                                          \
void add_last_##TYPE(struct node_##TYPE** headRef, TYPE d)      \
{                                                               \
    struct node_##TYPE* newNode;                                \
    newNode = (struct node_##TYPE*)malloc(sizeof(struct node_##TYPE)); \
                                                                       \
    struct node_##TYPE* last = *headRef;                               \
    newNode->value = d;                                                \
                                                                       \
    if (*headRef == NULL)                                              \
    {                                                                  \
        *headRef = newNode;                                            \
        return;                                                        \
    }                                                                  \
    while (last->next != NULL)                                         \
        last = last->next;                                             \
                                                                       \
    last->next = newNode;                                              \
    newNode->next = NULL;                                              \
}                                                                      \
