#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS
struct node
{
    int value;
    struct node* next;
};

void print_elements(struct node* head)
{
    struct node* p = head;
    while (p != NULL)
    {
        printf("%d\n", p->value);
        p = p->next;
    }
}

struct node* add_last(struct node** headRef, int d, struct node* prev)
{
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));

    newNode->next = NULL;
    newNode->value = d;

    if (*headRef == NULL)
    {
        *headRef = newNode;
        prev = newNode;
        return;
    }

    newNode->next = prev->next;
    prev->next = newNode;
    return newNode;
}

struct node* create_node()
{
    int value = 1;
    struct node* head = NULL;
    struct node* prev = NULL;

    printf("0 is the last element of the List\n");
    while (value != 0)
    {
        scanf("%d", &value);
        prev = add_last(&head, value, prev);
    }

    return head;
}

int main()
{
    struct node* head = create_node();
    print_elements(head);
}
