CREATE PROCEDURE sp_FinalizarOrcamento
    @OrcamentoId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM Orcamento
        WHERE Id = @OrcamentoId
    )
    BEGIN
        SELECT 'Erro: orçamento não encontrado.' AS Mensagem;
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM Orcamento
        WHERE Id = @OrcamentoId
          AND Status = 'Aberto'
    )
    BEGIN
        SELECT 'Erro: orçamento não está aberto.' AS Mensagem;
        RETURN;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM OrcamentoItem
        WHERE OrcamentoId = @OrcamentoId
    )
    BEGIN
        SELECT 'Erro: orçamento não possui itens.' AS Mensagem;
        RETURN;
    END;

    DECLARE @ValorTotal DECIMAL(18,2);

    SELECT @ValorTotal = SUM(Quantidade * ValorUnitario)
    FROM OrcamentoItem
    WHERE OrcamentoId = @OrcamentoId;

    UPDATE OrcamentoItem
    SET ValorTotal = Quantidade * ValorUnitario
    WHERE OrcamentoId = @OrcamentoId;

    UPDATE Orcamento
    SET Status = 'Finalizado',
        ValorTotal = @ValorTotal,
        DataFinalizacao = GETDATE()
    WHERE Id = @OrcamentoId;

    SELECT 'Sucesso: orçamento finalizado com sucesso.' AS Mensagem,
           @ValorTotal AS ValorTotal;
END;