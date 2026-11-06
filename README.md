# Glass Amazonya

Jogo 2D em **Unity** desenvolvido como **TCC**, ambientado na Amazônia. Você controla uma **arara-vermelha** que voa pela floresta, desvia de perigos e coleta frutos da região, como o **açaí**, para completar cada fase.

## Sobre o jogo

- **20 fases**, além de telas de abertura, menu, opções, "Como jogar", "Sobre", coletáveis, final e créditos.
- **Objetivo:** chegar ao açaí de cada fase sem perder a vida e antes que o tempo acabe.
- **Perigos:** árvores inimigas, fogo (queimadas) que avança pela fase e limite de tempo.
- **Coletáveis:** itens e frutos amazônicos que ficam salvos e podem ser vistos na tela de Coletáveis.
- **Gaiola:** cenas com a ave presa, que muda de aparência quando o jogador a alcança.
- **Idiomas:** português e inglês.
- **Controles:** a arara se move entre posições fixas da fase usando as teclas do teclado numérico (1 a 9).

## Tecnologias

- Unity **2020.3.15f2**
- C# (2D, física 2D, animações e UI)
- Newtonsoft.Json (salvamento de progresso)

## Como abrir o projeto

1. Instale o Unity Hub e o editor **2020.3.15f2**.
2. Clone este repositório.
3. No Unity Hub, clique em *Add* e selecione a pasta clonada.
4. Abra a cena `Assets/Scenes/Abetura.unity` e clique em *Play*.

## Estrutura

| Pasta | Conteúdo |
|---|---|
| `Assets/Scenes` | Telas do jogo e `Fases/` (Fase1 a Fase20) |
| `Assets/Scripts/Assembly-CSharp` | Scripts do jogo (controle, fases, idioma, save, som) |
| `Assets/Sprite`, `Texture2D` | Arte do jogo |
| `Assets/AudioClip` | Músicas e efeitos |
| `Assets/Plugins` | Bibliotecas de terceiros |

## Ajuste de tela

O script `ScreenAdapter.cs` adapta câmera e interface à resolução e à proporção do monitor do jogador, e reaplica o ajuste quando a janela é redimensionada.

## Aviso sobre a origem do código

Este projeto foi **recuperado a partir do jogo compilado** (build) com o AssetRipper. Por isso os scripts C# vêm de descompilação: os comentários e alguns nomes de variáveis originais se perderam, e prefabs e cenas reconstruídos podem precisar de pequenos ajustes ao abrir no Unity.

## Autor

Vitor Bazilio — [GitHub](https://github.com/VitorBazilio)
