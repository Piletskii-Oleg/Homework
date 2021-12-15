void delete_first(struct node** headRef)
{
    struct node* toDelete;

    if (*headRef == NULL)
        return;

    toDelete = *headRef;
    *headRef = (*headRef)->next;
    free(toDelete);
}

#define DELETE_FIRST(TYPE)                                          \
void delete_first_##TYPE(struct node_##TYPE** headRef)              \
{                                                                   \
    struct node_##TYPE* toDelete;                                   \
                                                                    \
    if (*headRef == NULL)                                           \
        return;                                                     \
                                                                    \
    toDelete = *headRef;                                            \
    *headRef = (*headRef)->next;                                    \
    free(toDelete);                                                 \
}                                                                   \

void delete_last(struct node* head)
{
    if (head == NULL || head->next == NULL)
        return;

    while (head->next->next != NULL)
    {
        head = head->next;
    }

    struct node* toDelete = head->next;
    head->next = NULL;
    free(toDelete);
}

#define DELETE_LAST(TYPE)                           \
void delete_last_##TYPE(struct node_##TYPE* head)   \
{                                                   \
    if (head == NULL || head->next == NULL)         \
        return;                                     \
                                                    \
    while (head->next->next != NULL)                \
    {                                               \
        head = head->next;                          \
    }                                               \
                                                    \
    struct node_##TYPE* toDelete = head->next;      \
    head->next = NULL;                              \
    free(toDelete);                                 \
}                                                   \
