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

_Bool is_empty(struct Stack root)
{
    return !root.head;
}

struct Stack push(struct Stack stack, int data)
{
    struct node* newNode = (struct node*)malloc(sizeof(struct node));
    newNode->data = data;
    newNode->next = stack.head;
    stack.head = newNode;
    printf("Element %d pushed to stack.\n", data);
    return stack;
}

int pop(struct Stack stack)
{
    if (is_empty(stack))
    {
        printf("Stack is empty.\n");
        return;
    }

    struct node* temp = stack.head;
    stack.head = (stack.head)->next;
    int popped = temp->data;
    free(temp);

    printf("Element %d popped.\n", popped);
    return popped;
}

int peek(struct Stack* root)
{
    return stack.head->data;
}

int main()
{
    struct Stack* stack = create_node(3);

    printf("Stack is empty: %d\n", is_empty(stack));
    push(&stack, 3);
    printf("Last element is: %d \n", peek(stack));
    push(&stack, 4);
    pop(&stack);
    pop(&stack);
    pop(&stack);
    pop(&stack);
    push(&stack, 6);
    pop(&stack);
}
