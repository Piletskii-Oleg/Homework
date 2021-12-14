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

void print_elements(struct node* head)
{
    struct node* p = head;
    while (p != NULL)
    {
        printf("%d\n", p->value);
        p = p->next;
    }
}

struct node* delete_element(struct node* head, int position) //3
{
    if (head == NULL)
        return;

    if (position == 0)
    {
        struct node* toDelete = head;
        head = head->next;
        free(toDelete);
        return head;
    }
    else
    {
        for (int i = 0; i < position - 1; i++)
        {
            head = head->next;
        }
        struct node* toDelete = head->next;
        head->next = head->next->next;
        free(toDelete);
        return head;
    }
}

void delete_all_elements(struct node** headRef) //4
{
    if ((*headRef) == NULL)
        return;

    struct node* element = *headRef;
    *headRef = (*headRef)->next;
    free(element);
    delete_all_elements(headRef);
}

int main()
{
    struct node* head = create_node();
    printf("\n");

    delete_all_elements(&head);
    printf("\n");
    print_elements(head);
}
