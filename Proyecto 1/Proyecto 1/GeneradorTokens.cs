﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    class GeneradorTokens
    {
        Token tokenObjeto;
        private int contador = 0;
        private int actualEstado = 0;
        private ArrayList listaTokens = new ArrayList();

        public void separarTokens(String texto)
        {
            texto = texto + " ";
            char caracter;
            string concatToken = "";
            bool enterComillas = false;
            bool comentario = false;
            bool comentarioCompleto = false;
            bool asterisco = false;
            for (int i = 0; i < texto.Length; i++)
            {

                caracter = texto[i];
                switch (actualEstado)
                {
                    //Estado inicial
                    case 0:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                case '-':
                                    concatToken += caracter;
                                    setActualEstado(4);
                                    break;
                                case '"':
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case 'v':
                                    concatToken += caracter;
                                    setActualEstado(9);
                                    break;
                                case 'f':
                                    concatToken += caracter;
                                    setActualEstado(17);
                                    break;
                                case '+':
                                    concatToken += caracter;
                                    setActualEstado(24);
                                    break;
                                case '*':
                                    concatToken += caracter;
                                    setActualEstado(28);
                                    break;
                                case '/':
                                    concatToken += caracter;
                                    setActualEstado(77);
                                    break;
                                case '&':
                                    concatToken += caracter;
                                    setActualEstado(26);
                                    break;
                                case '|':
                                     concatToken += caracter;
                                    setActualEstado(36);
                                    break;
                                case '<':
                                    concatToken += caracter;
                                    setActualEstado(30);
                                    break;
                                case '>':
                                    concatToken += caracter;
                                    setActualEstado(30);
                                    break;
                                case '=':
                                    concatToken += caracter;
                                    setActualEstado(31);
                                    break;
                                case '!':
                                    concatToken += caracter;
                                    setActualEstado(30);
                                    break;
                                case ';':
                                    concatToken += caracter;
                                    setActualEstado(32);
                                    break;
                                case '(':
                                    concatToken += caracter;
                                    setActualEstado(38);
                                    break;
                                case ')':
                                    concatToken += caracter;
                                    setActualEstado(39);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(23);
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion de numeros
                    case 1:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                               
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':

                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                case '.':
                                    concatToken += caracter;
                                    setActualEstado(2);
                                    break;
                                default:
                                     insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;
                        }
                    //Estado de que recibe un punto
                    case 2:
                        {
                            switch (caracter)
                            {
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(3);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    //Estado de que recibe un punto
                    case 3:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(3);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion que recibe un menos
                    case 4:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                    concatToken += caracter;
                                    setActualEstado(1);
                                    break;
                                case '-':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                               
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion que recibe comillas y una cadena 
                    case 6:
                        {
                            switch (caracter)
                            {
                                case '"':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '\n':
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    enterComillas = true;
                                    break;
                                default:
                                    if (i + 1 == texto.Length)
                                    {
                                        insertarToken(concatToken, 62);
                                        concatToken = "";
                                        setActualEstado(0);
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(6);

                                    }
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una e
                    case 9:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case 'e':
                                    concatToken += caracter;
                                    setActualEstado(10);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una r
                    case 10:
                        {
                            switch (caracter)
                            {
                                case 'r':
                                    concatToken += caracter;
                                    setActualEstado(11);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una d
                    case 11:
                        {
                            switch (caracter)
                            {
                                case 'd':
                                    concatToken += caracter;
                                    setActualEstado(12);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una a
                    case 12:
                        {
                            switch (caracter)
                            {
                                case 'a':
                                    concatToken += caracter;
                                    setActualEstado(13);
                                    break;
                                default:
                                   setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una d
                    case 13:
                        {
                            switch (caracter)
                            {
                                case 'd':
                                    concatToken += caracter;
                                    setActualEstado(14);
                                    break;
                                default:
                                   setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una e
                    case 14:
                        {
                            switch (caracter)
                            {
                                case 'e':
                                    concatToken += caracter;
                                    setActualEstado(15);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una r
                    case 15:
                        {
                            switch (caracter)
                            {
                                case 'r':
                                    concatToken += caracter;
                                    setActualEstado(16);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion recibe una o
                    case 16:
                        {
                            switch (caracter)
                            {
                                case 'o':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una f
                    case 17:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case 'a':
                                    concatToken += caracter;
                                    setActualEstado(18);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una a
                    case 18:
                        {
                            switch (caracter)
                            {
                                case 'l':
                                    concatToken += caracter;
                                    setActualEstado(19);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe una l
                    case 19:
                        {
                            switch (caracter)
                            {
                                case 's':
                                    concatToken += caracter;
                                    setActualEstado(20);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado de aceptacion que recibe una s
                    case 20:
                        {
                            switch (caracter)
                            {
                                case 'o':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    setActualEstado(62);
                                    i = i - 1;
                                    break;
                            }
                            break;
                        }
                    //Estado que recibe cualquier caracter
                    case 23:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '+':
                                case '-':
                                case '*':
                                case '/':
                                case '!':
                                case '>':
                                case '<':
                                case '=':
                                case '|':
                                case '&':
                                case '(':
                                case ')':
                                case ';':
                                case '"':
                                   insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    concatToken += caracter;
                                    setActualEstado(62);
                                    break;


                               
                            }
                            break;
                        }
                    //Estado de aceptacion que recibe un +
                    case 24:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '+':
                                case '\f':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                   insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                        //Estado que recibe el & y acepta &&
                    case 26:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\n':
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '&':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un *
                    case 28:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':

                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                   insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion de los operadores relacionales
                    case 30:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '=':
                                case '\f':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un =
                    case 31:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                   insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                case '=':
                                     concatToken += caracter;
                                    insertarToken(concatToken,30);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un ;
                    case 32:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un (
                    case 38:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe un )
                    case 39:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\n':
                                case '\b':
                                case '\f':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;

                            }
                            break;

                        }
                    //Estado que recibe el | y acepta ||
                    case 36:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                case '\n':
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '|':
                                    concatToken += caracter;
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                default:
                                    insertarToken(concatToken, 62);
                                    concatToken = "";
                                    i = i - 1;
                                    setActualEstado(0);
                                    break;
                            }
                            break;

                        }
                    //Estado de aceptacion que recibe una / y es el estado de aceptacion de los comentarios
                    case 77:
                        {
                            switch (caracter)
                            {
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':
                                    if (comentarioCompleto == true && asterisco == false)
                                    {
                                        if ((i + 1) != texto.Length)
                                        {
                                            concatToken += caracter;
                                            setActualEstado(77);
                                        }
                                        else
                                        {
                                            concatToken += caracter;
                                            insertarToken(concatToken, 62);
                                            concatToken = "";
                                            setActualEstado(0);
                                            comentario = false;
                                        }
                                    }
                                    else if (comentario == true)
                                    {
                                        if ((i + 1) == texto.Length)
                                        {
                                            insertarToken(concatToken, 78);
                                            concatToken = "";
                                            comentario = false;
                                            setActualEstado(0);
                                        }
                                        else
                                        {
                                            concatToken += caracter;
                                            setActualEstado(77);
                                        }
                                        
                                    }
                                   

                                        
                                        
                                    break;
                                case '\n':
                                    if (comentarioCompleto == false && comentario==false)
                                    {
                                        insertarToken(concatToken, getActualEstado());
                                        concatToken = "";
                                        comentario = false;
                                        setActualEstado(0);
                                    }
                                    else if (comentarioCompleto == true)
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                    }
                                    else
                                    {
                                        insertarToken(concatToken, 78);
                                        concatToken = "";
                                        comentario = false;
                                        setActualEstado(0);
                                    }
                                   
                                    break;
                                case '/':
                                    if (comentarioCompleto == true || comentario==true)
                                    {
                                        if (asterisco == true)
                                        {
                                            concatToken += caracter;
                                            insertarToken(concatToken, 79);
                                            concatToken = "";
                                            comentario = false;
                                            setActualEstado(0);
                                            comentarioCompleto = false;
                                            asterisco = false;
                                        }
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                        comentario = true;

                                    }
                                    break;
                                case '*':
                                    if (comentarioCompleto == false && comentario==false && asterisco==false)
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                        comentarioCompleto = true;
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                        asterisco = true;
                                    }
                                   
                                    break;
                                default:
                                    if (comentario == false && comentarioCompleto==false)
                                    {
                                        insertarToken(concatToken, getActualEstado());
                                        concatToken = "";
                                        i = i - 1;
                                        setActualEstado(0);
                                        break;
                                    }
                                    else
                                    {
                                        concatToken += caracter;
                                        setActualEstado(77);
                                    }
                                    break;

                            }
                            break;

                        }
                    //Estado de aceptacion que recibe todos los errores en el texto
                    case 62:
                        {
                            switch (caracter)
                            {
                                case '\n':
                                case ' ':
                                case '\r':
                                case '\t':
                                case '\b':
                                case '\f':

                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    setActualEstado(0);
                                    break;
                                case '+':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(24);
                                    break;
                                case '-':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(4);
                                    break;
                                case '"':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(6);
                                    break;
                                case '*':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(28);
                                    break;
                                case '/':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(77);
                                    break;
                                case '&':
                                    insertarToken(concatToken, getActualEstado());
                                    concatToken = "";
                                    concatToken += caracter;
                                    setActualEstado(26);
                                    break;
                                default:
                                    concatToken += caracter;
                                    break;
                            }
                            break;
                        }
                }
                if (caracter.Equals('\n') && (!enterComillas) && (!comentarioCompleto) )
                {
                    insertarToken(concatToken, 63);
                }
                else
                {
                    enterComillas = false;
                }

            }

        }


        public void setActualEstado(int estado)
        {
            this.actualEstado = estado;
        }
        public int getActualEstado()
        {
            return this.actualEstado;
        }

        public void insertarToken(string palabra, int estado)
        {
            Token tokenNuevo;
            switch (estado)
            {
                case 1:
                    tokenNuevo = new Token(palabra, "Morado", "Entero");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 3:
                    tokenNuevo = new Token(palabra, "Celeste", "Decimal");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 4:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorAritmetico");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 6:
                    tokenNuevo = new Token(palabra, "Gris", "Cadena");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 9:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 17:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 23:
                    tokenNuevo = new Token(palabra, "Cafe", "Caracter");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 24:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorAritmetico");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 26:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorLogico");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 28:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorAritmetico");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 30:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorRelacional");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 31:
                    tokenNuevo = new Token(palabra, "Rosa", "Sentencia");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 32:
                    tokenNuevo = new Token(palabra, "Rosa", "Sentencia");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 38:
                    tokenNuevo = new Token(palabra, "Azul", "Signo");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 39:
                    tokenNuevo = new Token(palabra, "Azul", "Signo");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 36:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorLogico");
                    listaTokens.Add(tokenNuevo);
                    break;

                case 77:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorAritmetico");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 78:
                    tokenNuevo = new Token(palabra, "Rojo", "Comentario");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 79:
                    tokenNuevo = new Token(palabra, "Rojo", "Comentario");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 8:
                    tokenNuevo = new Token(palabra, "Azul", "OperadorAritmetico");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 11:
                    tokenNuevo = new Token(palabra, "Gris", "Cadena");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 16:
                    tokenNuevo = new Token(palabra, "Naranja", "Booleano");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 20:
                    tokenNuevo = new Token(palabra, "Naranja", "Booleano");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 62:
                    tokenNuevo = new Token(palabra, "Blanco", "Error");
                    listaTokens.Add(tokenNuevo);
                    break;
                case 63:
                    tokenNuevo = new Token(palabra, "Negro", "Enter");
                    listaTokens.Add(tokenNuevo);
                    break;
            }
        }

        public ArrayList getTokens()
        {
            return listaTokens;
        }
        public void vaciarLista()
        {
            listaTokens.Clear();
        }
    }
}
