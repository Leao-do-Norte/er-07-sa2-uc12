﻿// See https://aka.ms/new-console-template for more information

using prog_backend.Classes;

Utils.BarraCarregamento(">> Inicializando", 10, ">", "Bem-vindo!");

List<PessoaFisica> listaPF = new List<PessoaFisica>();
List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

string? opcao;

do {
    Console.Clear();
    Console.WriteLine(@$"
    =================================================
    |       Bem vindo ao Sistema de Cadastro        |
    |        de Pessoas Físicas e Jurídicas         |
    =================================================
    |       Digite o número da opção desejada       |
    =================================================
    |               1 - Pessoa Física               |
    |               2 - Pessoa Jurídica             |
    |                                               |
    |               0 - Sair                        |
    =================================================
    ");

    opcao  = Console.ReadLine();

    switch (opcao){
    case "1":

        PessoaFisica metodoPF = new PessoaFisica();
        
        string? opcaoPF;
        do
        {
            Console.Clear();
            Console.WriteLine(@$"
            =================================================
            |       Digite o número da opção desejada       |
            =================================================
            |       1 - Cadastrar Pessoa Física             |
            |       2 - Mostrar Pessoas Físicas             |
            |                                               |
            |       0 - Voltar ao menu anterior             |
            =================================================
            ");

            opcaoPF = Console.ReadLine();

            switch (opcaoPF){
                case "1":
                    Console.Clear();
                    PessoaFisica novaPF = new PessoaFisica();
                    Endereco novoEnd = new Endereco();

                    Console.WriteLine($"Informe o nome: ");
                    novaPF.nome = Console.ReadLine();

                    bool dataValida;
                    do
                    {
                        Console.WriteLine($"Digite a data de nascimento (DD/MM/AAAA):");
                        string dataNasc = Console.ReadLine();
                        
                        dataValida = metodoPF.ValidarDataNascimento(dataNasc);

                        if (dataValida){
                            novaPF.dataNascimento = dataNasc;
                        } else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Data inválida, tente novamente");
                            Console.ResetColor(); 
                        } 
                    } while (dataValida == false);
                
                    novaPF.endereco = novoEnd;
                    
                    Console.WriteLine($"Digite somente os números do CPF: ");
                    novaPF.cpf = Console.ReadLine();

                    Console.WriteLine($"Digite o rendimento mensal (apenas números): ");
                    novaPF.rendimento = float.Parse(Console.ReadLine());
                    
                    float impostoPagar = novaPF.CalcularImposto(novaPF.rendimento);

                    Console.WriteLine($"Digite o logradouro: ");
                    novoEnd.logradouro = Console.ReadLine();

                    Console.WriteLine($"Digite o número: ");
                    novoEnd.numero = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine($"Digite o complemento: ");
                    novoEnd.complemento = Console.ReadLine();
                    
                    Console.WriteLine($"Este endereço é comercial?: ");
                    string endCom = Console.ReadLine().ToUpper();
                    if (endCom == "S"){
                        novoEnd.endComercial = true;
                    } else {
                        novoEnd.endComercial = false;
                    }
                    
                    listaPF.Add(novaPF);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Cadastro realizado com sucesso!");
                    Console.ResetColor();
                    Thread.Sleep(3000);

                    break;

                case "2":
                    Console.Clear();
                    if (listaPF.Count > 0)
                    {
                        foreach (PessoaFisica cadaPessoa in listaPF)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
            ---------------PESSOA FÍSICA------------------
            Nome: {cadaPessoa.nome}
            CPF: {cadaPessoa.cpf}
            Endereço: {cadaPessoa.endereco.logradouro}, N° {cadaPessoa.endereco.numero}, {cadaPessoa.endereco.complemento}
            ----------------------------------------------
            Data de Nascimento: {cadaPessoa.dataNascimento}
            Maior de idade: {cadaPessoa.ValidarDataNascimento(cadaPessoa.dataNascimento)}
            ----------------------------------------------
            Rendimento: {cadaPessoa.rendimento}
            Tributação: {metodoPF.CalcularImposto(cadaPessoa.rendimento).ToString("C")}
            ----------------------------------------------
                            "); 
                            Console.WriteLine($"Para continuar, tecle enter");
                            Console.ReadLine();
                        }
                    } else
                    {
                        Console.WriteLine($"Lista vazia!");
                        Thread.Sleep(3000);
                    }
                    
                break;

                case "0":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"Opção inválida!");
                    Thread.Sleep(3000);
                    break;
            }

        } while (opcaoPF != "0");

        break;

    case "2":

        PessoaJuridica metodoPJ = new PessoaJuridica();

        string? opcaoPJ;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
        ============================================================
        |               Escolha uma das opções abaixo              |
        |----------------------------------------------------------|
        |               1 - Cadastrar Pessoa Jurídica              |
        |               2 - Mostrar Pessoas Jurídicas              |
        |                                                          |
        |               0 - Voltar ao menu anterior                |
        ============================================================
            ");
            
            opcaoPJ = Console.ReadLine();

            switch (opcaoPJ)
            {
                case "1":
                    Console.Clear();
                    PessoaJuridica novaPJ = new PessoaJuridica();
                    Endereco novoEnd = new Endereco();

                    Console.WriteLine($"Razão social: ");
                    novaPJ.razaoSocial = Console.ReadLine();

                    // bool cnpjValido;
                    // do
                    // {
                    //     Console.WriteLine($"Digite o CNPJ: ");
                    //     string cnpjInfo = Console.ReadLine();
                        
                    //     cnpjValido = metodoPJ.ValidarCnpj(cnpjInfo);

                    //     if (cnpjValido){
                    //         novaPJ.cnpj = cnpjInfo;
                    //     } else {
                    //         Console.ForegroundColor = ConsoleColor.DarkRed;
                    //         Console.WriteLine($"CNPJ inválido, tente novamente");
                    //         Console.ResetColor(); 
                    //     } 
                    // } while (cnpjValido == false);

                    Console.WriteLine($"Digite o CNPJ: ");
                    novaPJ.cnpj = Console.ReadLine();
                    
                    Console.WriteLine($"Informe o rendimento: ");
                    novaPJ.rendimento = float.Parse(Console.ReadLine());
                    
                    novaPJ.endereco = novoEnd;
                    
                    Console.WriteLine($"Digite o logradouro: ");
                    novoEnd.logradouro = Console.ReadLine();

                    Console.WriteLine($"Digite o número: ");
                    novoEnd.numero = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine($"Digite o complemento: ");
                    novoEnd.complemento = Console.ReadLine();
                    
                    Console.WriteLine($"Este endereço é comercial? ");
                    string endCom = Console.ReadLine().ToUpper();
                    if (endCom == "S"){
                        novoEnd.endComercial = true;
                    } else {
                        novoEnd.endComercial = false;
                    }

                    listaPJ.Add(novaPJ);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Cadastro realizado com sucesso!");
                    Console.ResetColor();
                    Thread.Sleep(3000);

                    break;

                case "2":

                    if (listaPJ.Count > 0)
                    {
                        foreach (PessoaJuridica cadaPJuridica in listaPJ)
                        {
                            Console.WriteLine(@$"
        ---------------PESSOA JURÍDICA------------------
        Razão Social: {cadaPJuridica.razaoSocial}
        CNPJ: {cadaPJuridica.cnpj}
        Endereço: {cadaPJuridica.endereco.logradouro}, N° {cadaPJuridica.endereco.numero}, {cadaPJuridica.endereco.complemento}
        -----------------------------------------------
        CNPJ é válido? --> {cadaPJuridica.ValidarCnpj(cadaPJuridica.cnpj)}
        -----------------------------------------------
        Imposto a pagar: {cadaPJuridica.CalcularImposto(cadaPJuridica.rendimento).ToString("C")}
        -----------------------------------------------");
                            Console.WriteLine($"Para continuar, tecle enter");
                            Console.ReadLine();
                        }
                    } else {
                        Console.WriteLine($"Lista Vazia");
                        Thread.Sleep(2000);
                    }
                    
                    break;

                case "0":
                    break;
                
                default:
                    Console.Clear();
                    Console.WriteLine($"Opção Inválida!");
                    Thread.Sleep(3000);
                    break;
            }
            
        } while (opcaoPJ != "0");

        Console.WriteLine($"Para continuar, tecle enter");
        Console.ReadLine();
        break;
    
    case "0":
        Console.Clear();
        Console.WriteLine($"Até a próxima!");
        Thread.Sleep(1500);
        break;
    
    default:
        Console.Clear();
        Console.WriteLine($"Opção inválida!");
        Console.WriteLine($"Para continuar, tecle enter");
        Console.ReadLine();
        break;
    }
} while (opcao != "0");

Utils.BarraCarregamento("<< Encerrando", 5, "<", "Tchau!");