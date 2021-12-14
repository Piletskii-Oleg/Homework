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
        printf("%d ", p->value);
        p = p->next;
    }
}

struct node* create_list()
{
    struct node* head = (struct node*)malloc(sizeof(struct node));
    head->value = 1;
    struct node* Head = head;
    for (int i = 2; i <= 40; i++)
    {
        struct node* newNode = (struct node*)malloc(sizeof(struct node));
        head->next = newNode;
        newNode->value = i;
        head = head->next;
    }
    head->next = Head;
    return Head;
}

void delete_element(struct node** headRef)
{
    struct node* toDelete;
    toDelete = (*headRef)->next;
    (*headRef)->next = (*headRef)->next->next;
    free(toDelete);
}

void josephus_flavius_problem()
{
    struct node* head = create_list();

    for (int j = 0; j < 3; j++)
    {
        head = head->next;
    }
    delete_element(&head);

    while(1)
    {
        for (int j = 0; j < 4; j++)
        {
            head = head->next;
        }

        printf("%d\n", head->next->value);

        if (head->next != head)
            delete_element(&head);
        else
            break;
    }
}

int main()
{
    josephus_flavius_problem();
}
