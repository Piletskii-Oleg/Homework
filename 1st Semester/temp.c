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

struct node* create_first(int value)
{
	struct node* newNode = (struct node*)malloc(sizeof(struct node));
	newNode->value = value;
	newNode->next = NULL;
	return newNode;
}

void add_new(struct node* head, int value)
{

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
}
