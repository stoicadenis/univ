#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

enum { ID, INT, REAL, STR, VAR, FUNCTION, IF, ELSE, WHILE, END, RETURN, TYPE_INT, TYPE_REAL, TYPE_STR,
		COLON, SEMICOLON, LPAR, RPAR, COMMA, OR, AND, NOT, EQUAL, NOTEQUAL, LESS, ASSIGN, ADD, SUB, MUL, DIV, FINISH};	// toate codurile atomilor din Quick, fara SPACE si COMMENT

const char* numeAtomi[] = { "ID", "INT", "REAL", "STR", "VAR", "FUNCTION", "IF", "ELSE", "WHILE", "END", "RETURN", "TYPE_INT", "TYPE_REAL", "TYPE_STR",
		"COLON", "SEMICOLON", "LPAR", "RPAR", "COMMA", "OR", "AND", "NOT", "EQUAL", "NOTEQUAL", "LESS", "ASSIGN", "ADD", "SUB", "MUL", "DIV", "FINISH" };

typedef struct {
	int cod;		// codul atomului ( ID, INT, ...)
	int linie;
	union
	{
		char text[128];
		double r;
		int i;
	};
}Atom;
Atom atomi[10000];	// vectorul cu atomii extrasi din fisierul de intrare
int nAtomi=0;	// numarul de atomi din vectorul atomi
int iCrtAtom = 0;

char bufin[30001];
char* pch;	// cursor la caracterul curent din bufin
int linie = 1;

void addAtom(int codAtom)
{
	atomi[nAtomi].cod = codAtom;
	atomi[nAtomi].linie = linie;
	nAtomi++;
}

// la fiecare apel returneaza codul unui atom
int getNextTk()			// get next token (atom lexical)
{
	int state = 0;		// starea curenta
	char buf[128];
	int n = 0;
	for (;;) {
		char ch = *pch;	// caracterul curent
		//printf("#%d %c(%d)\n", state, ch, ch);	// pt debugging
		// cate un case pentru fiecare stare din diagrama
		switch (state) {
		case 0:
			// testam toate tranzitiile posibile din acea stare
			if (isalpha(ch) || ch == '_') { state = 1; pch++; buf[n++]=ch; }
			else if (isdigit(ch)) { state = 4; pch++; buf[n++] = ch; }
			else if (ch == ' ' || ch == '\r' || ch == '\n' || ch == '\t') 
			{ 
				pch++; 
				if (ch == '\n') linie++;
			}
			else if (ch == '#') { state = 3; pch++; }
			else if (ch == '"') { state = 9; pch++; buf[n++] = ch; }
			else if (ch == ':') { state = 11; pch++; }
			else if (ch == ';') { state = 12; pch++; }
			else if (ch == '(') { state = 13; pch++; }
			else if (ch == ')') { state = 14; pch++; }
			else if (ch == ',') { state = 15; pch++; }
			else if (ch == '|') { state = 16; pch++; }
			else if (ch == '&') { state = 18; pch++; }
			else if (ch == '!') { state = 20; pch++; }
			else if (ch == '=') { state = 23; pch++; }
			else if (ch == '<') { state = 26; pch++; }
			else if (ch == '+') { state = 27; pch++; }
			else if (ch == '-') { state = 28; pch++; }
			else if (ch == '*') { state = 29; pch++; }
			else if (ch == '/') { state = 30; pch++; }
			else if (ch == '\0') { state = 31; pch++; }
			else
			{
				printf("Caracter invalid: %c", ch);
				exit(1);
			}
			break;
		case 1:
			if (isalnum(ch) || ch == '_') { pch++; buf[n++] = ch; }
			else { state = 2; }
			break;
		case 2:
			buf[n] = '\0';
			if (strcmp(buf, "var")==0) { addAtom(VAR); return VAR; }
			else if (strcmp(buf, "function")==0) { addAtom(FUNCTION); return FUNCTION; }
			else if (strcmp(buf, "if")==0) { addAtom(IF); return IF; }
			else if (strcmp(buf, "else")==0) { addAtom(ELSE); return ELSE; }
			else if (strcmp(buf, "while")==0) { addAtom(WHILE); return WHILE; }
			else if (strcmp(buf, "end")==0) { addAtom(END); return END; }
			else if (strcmp(buf, "return")==0) { addAtom(RETURN); return RETURN; }
			else if (strcmp(buf, "int")==0) { addAtom(TYPE_INT); return TYPE_INT; }
			else if (strcmp(buf, "real")==0) { addAtom(TYPE_REAL); return TYPE_REAL; }
			else if (strcmp(buf, "str")==0) { addAtom(TYPE_STR); return TYPE_STR; }
			{
				addAtom(ID);	// adauga atomul gasit in lista de atomi
				strcpy(atomi[nAtomi - 1].text, buf);
				return ID;
			}
		case 3:
			if (ch != '\r' && ch != '\n' && ch != '\0') { pch++; }
			else { state = 0; }
			break;
		case 4:
			if (isdigit(ch)) { pch++; buf[n++] = ch; }
			else if (ch == '.') { state = 6; pch++; buf[n++] = ch; }
			else { state = 5; }
			break;
		case 5:
			buf[n] = '\0';
			addAtom(INT);
			atomi[nAtomi-1].i=atoi(buf);
			return INT;
		case 6:
			if (isdigit(ch)) { state = 7; pch++; buf[n++] = ch; }
			break;
		case 7:
			if (isdigit(ch)) { pch++; buf[n++] = ch; }
			else { state = 8; }
			break;
		case 8:
			buf[n] = '\0';
			addAtom(REAL);
			atomi[nAtomi - 1].r = atof(buf);
			return REAL;
		case 9:
			if (ch != '"') { pch++; buf[n++] = ch; }
			else { state = 10; pch++; buf[n++] = ch; }
			break;
		case 10:
			buf[n] = '\0';
			addAtom(STR);
			strcpy(atomi[nAtomi - 1].text, buf);
			return STR;
		case 11:
			addAtom(COLON);
			return COLON;
		case 12:
			addAtom(SEMICOLON);
			return SEMICOLON;
		case 13:
			addAtom(LPAR);
			return LPAR;
		case 14:
			addAtom(RPAR);
			return RPAR;
		case 15:
			addAtom(COMMA);
			return COMMA;
		case 16:
			if (ch == '|') { state = 17; pch++; }
			break;
		case 17:
			addAtom(OR);
			return OR;
		case 18:
			if (ch == '&') { state = 19; pch++; }
			break;
		case 19:
			addAtom(AND);
			return AND;
		case 20:
			if (ch == '=') { state = 21; pch++; }
			else { state = 22; }
			break;
		case 21:
			addAtom(NOTEQUAL);
			return NOTEQUAL;
		case 22:
			addAtom(NOT);
			return NOT;
		case 23:
			if (ch == '=') { state = 24; pch++; }
			else { state = 25; }
			break;
		case 24:
			addAtom(EQUAL);
			return EQUAL;
		case 25:
			addAtom(ASSIGN);
			return ASSIGN;
		case 26:
			addAtom(LESS);
			return LESS;
		case 27:
			addAtom(ADD);
			return ADD;
		case 28:
			addAtom(SUB);
			return SUB;
		case 29:
			addAtom(MUL);
			return MUL;
		case 30:
			addAtom(DIV);
			return DIV;
		case 31:
			addAtom(FINISH);
			return FINISH;
		default: 
			printf("Stare invalida %d\n", state);
			break;
		}
	}

}

void err(const char* msg)
{
	printf("Eroare in linia %d: ", atomi[iCrtAtom].linie);
	printf("%s\n", msg);
	exit(EXIT_FAILURE);
}

int consume(int cod)
{
	if (atomi[iCrtAtom].cod == cod)
	{
		iCrtAtom++;
		return 1;
	}
	return 0;
}

int baseType()
{
	int start = iCrtAtom;
	if (consume(TYPE_INT))
	{
		return 1;
	}
	else
	{
		if (consume(TYPE_REAL))
		{
			return 1;
		}
		else
		{
			if (consume(TYPE_STR))
			{
				return 1;
			}
		}
	}
	iCrtAtom = start;
	return 0;
}

int funcParam()
{
	int start = iCrtAtom;
	if (consume(ID))
	{
		if (consume(COLON))
		{
			if (baseType())
			{
				return 1;
			}
			else
				err("lipseste tipul parametrului functiei");
		}
		else
			err("lipsesc : dupa numele parametrului functiei");
	}
	iCrtAtom = start;
	return 0;
}

int funcParams()
{
	int start = iCrtAtom;
	if (funcParam())
	{
		for (;;)
		{
			if (consume(COMMA))
			{
				if (funcParam())
				{

				}
				else
				{
					err("lipseste parametrul functiei dupa ,");
					iCrtAtom = start;
					return 0;
				}
			}
			else
				break;
		}
	}
	return 1;
}

int expr();

int factor()
{
	int start = iCrtAtom;
	if (consume(INT))
	{
		return 1;
	}
	else
	{
		if (consume(REAL))
		{
			return 1;
		}
		else
		{
			if (consume(STR))
			{
				return 1;
			}
			else
			{
				if (consume(LPAR))
				{
					if (expr())
					{
						if (consume(RPAR))
						{
							return 1;
						}
						else
							err("lipseste ) dupa expresia logica");
					}
					else
						err("lipseste expresia logica dupa (");
				}
				else
				{
					if (consume(ID))
					{
						if (consume(LPAR))
						{
							if (expr())
							{
								for (;;)
								{
									if (consume(COMMA))
									{
										if (expr())
										{

										}
										else
										{
											err("lipseste expresia logica dupa ,");
											iCrtAtom = start;
											return 0;
										}
									}
									else
										break;
								}								
							}
							if (consume(RPAR))
							{

							}
							else
							{
								err("lipseste ) la finalul factorului");
								iCrtAtom = start;
								return 0;
							}
						}
						return 1;
					}
					iCrtAtom = start;
					return 0;
				}
			}
		}
	}
}

int exprPrefix()
{
	int start = iCrtAtom;
	if (consume(SUB))
	{

	}
	else
	{
		if (consume(NOT))
		{

		}
	}
	if (factor())
	{
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int exprMul()
{
	int start = iCrtAtom;
	if (exprPrefix())
	{
		for (;;)
		{
			if (consume(MUL) || consume(DIV))
			{
				if (exprPrefix())
				{

				}
				else
				{
					err("lipseste expresia dupa * sau /");
					iCrtAtom = start;
					return 0;
				}
			}
			else
				break;
		}
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int exprAdd()
{
	int start = iCrtAtom;
	if (exprMul())
	{
		for (;;)
		{
			if (consume(ADD) || consume(SUB))
			{
				if (exprMul())
				{

				}
				else
				{
					err("lipseste expresia dupa + sau -");
					iCrtAtom = start;
					return 0;
				}
			}
			else
				break;
		}
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int exprComp()
{
	int start = iCrtAtom;
	if (exprAdd())
	{
		if (consume(LESS) || consume(EQUAL))
		{
			if (exprAdd())
			{

			}
			else
			{
				err("lipseste expresia dupa < sau ==");
				iCrtAtom = start;
				return 0;
			}
		}
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int exprAssign()
{
	int start = iCrtAtom;
	if (consume(ID))
	{
		if (consume(ASSIGN))
		{

		}
		else
		{
			iCrtAtom = start;
		}
	}
	if (exprComp())
	{
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int exprLogic()
{
	int start = iCrtAtom;
	if (exprAssign())
	{
		for (;;)
		{
			if (consume(AND) || consume(OR))
			{
				if (exprAssign())
				{

				}
				else
				{
					err("lipseste expresia dupa && sau ||");
					iCrtAtom = start;
					return 0;
				}
			}
			else
				break;
		}
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int expr()
{
	int start = iCrtAtom;
	if (exprLogic())
	{
		return 1;
	}
	iCrtAtom = start;
	return 0;
}

int block();

int instr()
{
	int start = iCrtAtom;
	if (consume(WHILE))
	{
		if (consume(LPAR))
		{
			if (expr())
			{
				if (consume(RPAR))
				{
					if (block())
					{
						if (consume(END))
						{
							return 1;
						}
						else
							err("lipseste sfarsitul while-ului");
					}
					else
						err("lipseste blocul de instructiuni al while-ului");
				}
				else
					err("lipseste ) dupa expresia logica");
			}
			else
				err("lipseste expresia logica a while-ului");
		}
		else
			err("lipseste ( dupa while");
	}
	else
	{
		if (consume(RETURN))
		{
			if (expr())
			{
				if (consume(SEMICOLON))
				{
					return 1;
				}
				else
					err("lipseste ; dupa expresia logica");
			}
			else
				err("lipseste expresia logica a return-ului");
		}
		else
		{
			if (consume(IF))
			{
				if (consume(LPAR))
				{
					if (expr())
					{
						if (consume(RPAR))
						{
							if (block())
							{
								if (consume(ELSE))
								{
									if (block())
									{

									}
									else
									{
										err("lipseste blocul de instructiuni al else-ului");
										iCrtAtom = start;
										return 0;
									}
								}
								if (consume(END))
								{
									return 1;
								}
								else
									err("lipseste sfarsitul if-ului");
							}
							else
								err("lipseste blocul de instructiuni al if-ului");
						}
						else
							err("lipseste ) dupa expresia logica");
					}
					else
						err("lipseste expresia logica a if-ului");
				}
				else
					err("lipseste ( dupa if");
			}
			else
			{
				if (expr())
				{

				}
				if (consume(SEMICOLON))
				{
					return 1;
				}
			}
		}
	}
	iCrtAtom = start;
	return 0;
}

int block()
{
	int start = iCrtAtom;
	if (instr())
	{

	}
	else
	{
		iCrtAtom = start;
		return 0;
	}
	for (;;)
	{
		if (instr())
		{

		}
		else
			break;
	}
	return 1;
}

int defVar()
{
	int start = iCrtAtom;
	if (consume(VAR))
	{
		if (consume(ID))
		{
			if (consume(COLON))
			{
				if (baseType())
				{
					if (consume(SEMICOLON))
					{
						return 1;
					}
					else
						err("lipseste ; dupa tipul variabilei");
				}
				else
					err("lipseste tipul variabilei");
			}
			else
				err("lipsesc : dupa numele variabilei");
		}
		else
			err("lipseste numele variabilei");
	}
	iCrtAtom = start;
	return 0;
}

int defFunc()
{
	int start = iCrtAtom;
	if (consume(FUNCTION))
	{
		if (consume(ID))
		{
			if (consume(LPAR))
			{
				if (funcParams())
				{
					if (consume(RPAR))
					{
						if (consume(COLON))
						{
							if (baseType())
							{
								for (;;)
								{
									if (defVar())
									{

									}
									else
										break;
								}
								if (block())
								{
									if (consume(END))
									{
										return 1;
									}
									else
										err("lipseste sfarsitul functiei");
								}
								else
									err("lipseste blocul functiei");
							}
							else
								err("lipseste tipul functiei");
						}
						else
							err("lipsesc : dupa )");
					}
					else
						err("lipseste ) dupa parametrii functiei");
				}
			}
			else
				err("lipseste ( dupa numele functiei");
		}
		else
			err("lipseste numele functiei");
	}
	iCrtAtom = start;
	return 0;
}

int program()
{
	int start = iCrtAtom;
	for (;;)
	{
		if (defVar())
		{

		}
		else
		{
			if (defFunc())
			{

			}
			else
			{
				if (block())
				{

				}
				else
				{
					break;
				}
			}
		}
	}
	if (consume(FINISH))
	{
		return 1;
	}
	else
		err("eroare de sintaxa");
	iCrtAtom = start;
	return 0;
}

int main()
{
	FILE* fis;
	fis = fopen("1.q", "rb");
	if (fis == NULL) {
		printf("Nu s-a putut deschide fisierul");
		return -1;
	}
	int n = fread(bufin, 1, 30000, fis);	// returneaza nr de elemente citite integral
	bufin[n] = '\0';
	fclose(fis);
	pch = bufin;	// initializare pch pe prima pozitie din bufin
	// extragere atomi
	while (getNextTk() != FINISH) {
	}
	// afisare atomi
	for (int i = 0; i < nAtomi; i++)
	{
		printf("%d ", atomi[i].linie);
		if (numeAtomi[atomi[i].cod] == "ID")
		{
			printf("ID:%s\n", atomi[i].text);
		}
		else
		{
			if (numeAtomi[atomi[i].cod] == "STR")
			{
				printf("STR:%s\n", atomi[i].text);
			}
			else
			{
				if (numeAtomi[atomi[i].cod] == "INT")
				{
					printf("INT:%d\n", atomi[i].i);
				}
				else
				{
					if (numeAtomi[atomi[i].cod] == "REAL")
					{
						printf("REAL:%lf\n", atomi[i].r);
					}
					else
					{
						printf("%s\n", numeAtomi[atomi[i].cod]);
					}
				}
			}
		}
	}

	iCrtAtom = 0;
	if (program())
	{
		printf("Sintaxa OK\n");
	}
	else
	{
		printf("Eroare de sintaxa!!!");
	}
	system("pause");
	return 0;
}