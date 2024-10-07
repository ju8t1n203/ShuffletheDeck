'Justin Bell
'RCET0265
'Fall 2024
'Shuffle the Deck
'https://github.com/ju8t1n203/ShuffletheDeck

Option Compare Text
Option Explicit On
Option Strict On
Module ShuffletheDeck

    Sub Main()
        Dim deck(13, 3) As Boolean
        Dim done As Boolean = False
        Dim userinput As String
        Dim cardsDrawn As Integer = 0

        Do
            Display(deck)
            If cardsDrawn < 52 Then
                DrawBall(deck)
                cardsDrawn += 1
                Console.WriteLine("Press enter to draw a card")
            Else
                Console.WriteLine("All cards have been drawn")
            End If
            Console.WriteLine("Press ""N"" for new deck")
            Console.WriteLine("Press ""Q"" to quit")

            userinput = Console.ReadLine()

            If userinput = "q" Then
                done = True
            ElseIf userinput = "n" Then
                ReDim deck(13, 3)
                cardsDrawn = 0
            End If

            Console.Clear()
        Loop Until done = True

        Console.WriteLine("Have a nice day!!!")
        Console.Read()
    End Sub

    Sub DrawBall(ByRef deck(,) As Boolean)
        Dim _number As Integer
        Dim _suite As Integer

        Do
            _number = GetRandomNumber(13, 1)
            _suite = GetRandomNumber(3, 0)
        Loop Until Not deck(_number, _suite)

        deck(_number, _suite) = True

    End Sub

    Sub Display(ByRef deck(,) As Boolean)
        Console.OutputEncoding = System.Text.Encoding.UTF8
        Dim prettyNumber As String
        Dim header() As String = {ChrW(&H2660), ChrW(&H2663), ChrW(&H2665), ChrW(&H2666)}

        For i = 0 To 3
            Console.Write($"| {header(i)} | ")
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(23, "-"))

        For number = 1 To 13
            For suite = 0 To 3
                'Console.Write(BallCage(number, letter))
                Console.Write("| ".PadLeft(1))
                Select Case deck(number, suite)
                    Case True
                        Select Case number
                            Case 1
                                prettyNumber = "A"
                            Case 11
                                prettyNumber = "J"
                            Case 12
                                prettyNumber = "Q"
                            Case 13
                                prettyNumber = "K"
                            Case Else
                                prettyNumber = CStr(number)
                        End Select
                    Case False
                        prettyNumber = ""
                End Select
                Console.Write(prettyNumber.PadRight(1) & " | ")
            Next
            Console.WriteLine()
        Next
    End Sub

    Function GetRandomNumber(max%, min%) As Integer
        Dim randomNumber%
        Randomize(DateTime.Now.Millisecond)
        randomNumber = CInt(Math.Floor(Rnd() * (max% - min% + 1))) + min%

        Return randomNumber%
    End Function
    'creates a random number in a specified range
End Module
