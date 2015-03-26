Module Module1

    Sub Main()
        Using d_old As New france_oldDataContext

            Using d_new As New new_oibDataContext
                Console.WriteLine("Processing Story Images")
                For Each row In d_new.AP_Stories
                    Dim q = (From c In d_old.Files Where c.FileId = row.PhotoId And c.PortalId = 0).FirstOrDefault
                    If Not q Is Nothing Then
                        Dim q_new = (From c In d_new.Files Where c.PortalId = 0 And c.FileName = q.FileName And c.Folder = q.Folder).FirstOrDefault
                        If Not q_new Is Nothing Then
                            Console.WriteLine(row.PhotoId & " -> " & q_new.FileId)
                            row.PhotoId = q_new.FileId
                        Else
                            Console.WriteLine("Could not locate FileId " & row.PhotoId & " in new system")
                        End If
                    Else
                        Console.WriteLine("Could not locate FileId " & row.PhotoId & " in old system")
                    End If
                Next
                d_new.SubmitChanges()
                Console.WriteLine("Processing Channel Images")
                For Each row In d_new.AP_Stories_Module_Channels
                    Dim q = (From c In d_old.Files Where c.FileId = row.ImageId And c.PortalId = 0).FirstOrDefault
                    If Not q Is Nothing Then
                        Dim q_new = (From c In d_new.Files Where c.PortalId = 0 And c.FileName = q.FileName And c.Folder = q.Folder).FirstOrDefault
                        If Not q_new Is Nothing Then
                            Console.WriteLine(row.ImageId & " -> " & q_new.FileId)
                            row.ImageId = q_new.FileId

                        Else
                            Console.WriteLine("Could not locate FileId " & row.PhotoId & " in new system")
                        End If
                    Else
                        Console.WriteLine("Could not locate FileId " & row.PhotoId & " in old system")
                    End If
                Next
                d_new.SubmitChanges()
            End Using
        End Using
        Console.WriteLine("finished. press any key.")
        Console.ReadKey()
    End Sub

End Module
