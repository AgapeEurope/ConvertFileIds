Module Module1

    Sub Main()
        Using d_old As New france_oldDataContext
            Using d_new As New new_oibDataContext

                For Each row In d_new.AP_Stories
                    Dim q = (From c In d_old.Files Where c.FileId = row.PhotoId And c.PortalId = 0).FirstOrDefault
                    If Not q Is Nothing Then
                        Dim q_new = (From c In d_new.Files Where c.PortalId = 0 And c.FileName = q.FileName And c.Folder = q.Folder).FirstOrDefault
                        If Not q_new Is Nothing Then
                            row.PhotoId = q_new.FileId

                        End If
                    End If
                Next
                d_new.SubmitChanges()
                For Each row In d_new.AP_Stories_Module_Channels
                    Dim q = (From c In d_old.Files Where c.FileId = row.ImageId And c.PortalId = 0).FirstOrDefault
                    If Not q Is Nothing Then
                        Dim q_new = (From c In d_new.Files Where c.PortalId = 0 And c.FileName = q.FileName And c.Folder = q.Folder).FirstOrDefault
                        If Not q_new Is Nothing Then
                            row.ImageId = q_new.FileId

                        End If
                    End If
                Next
                d_new.SubmitChanges()
            End Using
        End Using

    End Sub

End Module
