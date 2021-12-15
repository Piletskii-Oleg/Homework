#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct node
{
    int data;
    struct node* next;
};

struct Stack
{
    struct node* head;
};

struct Stack* create_node(int data)
{
    struct Stack* stackNode = (struct Stack*)malloc(sizeof(struct Stack));
    stackNode->data = data;
    stackNode->next = NULL;
}

struct Stack* is_empty(struct Stack* root)
{
    return !root;
}

void push(struct Stack** root, int data)
{
    struct Stack* newStackNode = create_node(data);
    newStackNode->next = *root;
    *root = newStackNode;
    printf("Element %d pushed to stack.\n", data);
}

void pop(struct Stack** root)
{
    struct Stack* temp = *root;
    *root = (*root)->next;
    int popped = temp->data;
    free(temp);

    printf("Element %d popped.\n", popped);
}

int peek(struct Stack* root)
{
    return root->data;
}

int main()
{
    struct Stack* stack = create_node(3);

    printf("Stack is empty: %d\n", is_empty(stack));
    push(&stack, 3);
    printf("Last element is: %d \n", peek(stack));
    push(&stack, 4);
    pop(&stack);
}
