struct node* find_element(struct node* head, int position)
{
    struct node* p = head;
    for (int i = 0; i < position; i++)
    {
        p = p->next;
    }
    return p;
}

#define FIND_ELEMENT(TYPE)                                                            \
struct node_##TYPE* find_element_##TYPE(struct node_##TYPE* head, int position)                     \
{                                                                                     \
    struct node_##TYPE* p = head;                                                            \
    for (int i = 0; i < position; i++)                                                \
    {                                                                                 \
        p = p->next;                                                                  \
    }                                                                                 \
    return p;                                                                         \
}                                                                                     \
