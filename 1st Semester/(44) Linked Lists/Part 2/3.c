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
    if (head == NULL)
        return;

    printf("%d\n", head->value);
    print_elements(head->next);
}

struct node* add_element(struct node* head, int value, int position)
{
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));

    if (position == 0)
    {
        newNode->value = value;
        newNode->next = head;
        head = newNode;
        return head;
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
    struct node* newNode;
    newNode = (struct node*)malloc(sizeof(struct node));
    newNode->value = value;

    struct node* new = *headRef;
    struct node** newnew = headRef;

    for (int i = 0; i < position; i++)
    {
        if (new->next != NULL)
        {
            newnew = &(new->next);
            new = new->next;
        }
    }

    newNode->next = *newnew;
    *newnew = newNode;
}

int main()
{
	struct node* head;
	struct node* one = malloc(sizeof(struct node));
	struct node* two = malloc(sizeof(struct node));
	struct node* three = malloc(sizeof(struct node));
	struct node* four = malloc(sizeof(struct node));

	one->next = two;
	two->next = three;
	three->next = four;
	four->next = NULL;
	head = one;

	one->value = 1;
	two->value = 2;
	three->value = 3;
	four->value = 50;

    print_elements(head);
    printf("\n");
    add_another_element(&head, 506, 0);
    print_elements(head);
}
