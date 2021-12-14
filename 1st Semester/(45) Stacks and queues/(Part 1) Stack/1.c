#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct Stack
{
    int top;
    int length;
    int* array;
};

struct Stack* create_stack(int length)
{
    struct Stack* stack = (struct Stack*)malloc(sizeof(int));
    stack->length = length;
    stack->top = -1;
    stack->array = (int*)malloc(stack->length * sizeof(int));
    return stack;
}

int is_empty(struct Stack* stack)
{
    return stack->length == 0;
}

int is_full(struct Stack* stack)
{
    return stack->top == stack->length - 1;
}

void push(struct Stack* stack, int element)
{
    if (is_full(stack))
        printf("The stack is already full!\n");
    else
    {
        stack->top++;
        stack->array[stack->top] = element;
        printf("Element %d pushed to stack.\n", element);
    }
}

void pop(struct Stack* stack)
{
    if (is_empty(stack))
        printf("The stack is empty!\n");
    else
    {
        printf("Element %d popped.\n", stack->array[stack->top]);
        stack->top--;
    }
}

int peek(struct Stack* stack)
{
    return stack->array[stack->top];
}

int main()
{
    int capacity;
    print("Input the stack capacity: ");
    scanf("%d", capacity);

    struct Stack* stack = create_stack(capacity);

    printf("Stack is empty: %d\n", is_empty(stack));
    push(stack, 3);
    printf("Last element is: %d \n", peek(stack));
    push(stack, 4);
    pop(stack);
}
