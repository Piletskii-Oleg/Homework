#define NODE_LENGTH(TYPE)                \
int node_length_##TYPE(struct Node_##TYPE* f) \
{                                        \
    struct Node_##TYPE* p = f;           \
                                         \
    int i = 0;                           \
    while (p != 0)                       \
    {                                    \
        ++i;                             \
        p = p->next;                     \
    }                                    \
    return i;                            \
}                                        \