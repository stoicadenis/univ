#include <stdio.h>
#include <stdlib.h>

int citire(int *v)
{
    FILE *f = fopen("nr.txt", "r");
    int i=0, n;
    if(!f)
    {
        perror("Nu s-a putut deschide fisierul de citire!\n");
        exit(EXIT_FAILURE);
    }
    fscanf(f, "%d", &n);
    while(fscanf(f, "%d", &v[i]) != EOF) i++;
    fclose(f);
    return n;
}

void cerinta(int *v, int n, char *nume_fisier)
{
    FILE *g = fopen(nume_fisier, "w");
    if(!g)
    {
        perror("Eroare la deschiderea fisierului de iesire!\n");
        exit(EXIT_FAILURE);
    }
    int d, i, nr, ok;
    for (i = 0; i < n; i++)
    {
        ok=1;
        d=2;
        while(d<v[i] && ok == 1)
        {
            if (v[i]%d==0) ok=0;
            else d++;
        }
        if (ok==1)
        {
            nr=v[i];
            while(nr>9) nr=nr/10;
            if(nr%2!=0) fprintf(g, "%d\n", v[i]);
        }
    }
    fclose(g);
}

int main(void)
{
    int n, v[50];
    char nume_fisier[20];
    printf("Numele fisierului de iesire este: ");
    scanf("%s", nume_fisier);
    n = citire(v);
    cerinta(v,n,nume_fisier);
}
