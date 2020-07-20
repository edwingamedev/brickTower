using UnityEngine;

namespace EdwinGameDev
{
    public class BlockStructure
    {
        private Vector2Int[,] JLSTZ_OFFSET { get; set; }
        private Vector2Int[,] I_OFFSET { get; set; }
        private Vector2Int[,] O_OFFSET { get; set; }

        public BlockStructure()
        {
            CreateAllBlockOffSets();
        }

        public Vector2Int[,] GetBlockOffset(BlockType blockType)
        {
            switch (blockType)
            {
                case BlockType.S:
                case BlockType.Z:
                case BlockType.L:
                case BlockType.J:
                case BlockType.T:
                    return JLSTZ_OFFSET;
                case BlockType.O:
                    return O_OFFSET;
                case BlockType.I:
                    return I_OFFSET;

                default:
                    return null;
            }
        }

        public Piece[] GetPieces(GameObject piecePrefab, Vector2Int spawnPosition, BlockType blockType, Transform parent, Sprite pieceSprite)
        {
            // Creates a block structure, using 4 pieces
            Piece[] pieces = new Piece[4];

            // Spawn GameObject and gets the Piece component to it
            for (int i = 0; i < pieces.Length; i++)
            {
                GameObject piece = GameObject.Instantiate(piecePrefab, new Vector2(spawnPosition.x, spawnPosition.y), Quaternion.identity, parent);
                pieces[i] = piece.GetComponent<Piece>();

                // Sets the corresponding sprite
                pieces[i].SetSprite(pieceSprite);
            }

            pieces[0].UpdatePosition(spawnPosition);

            switch (blockType)
            {
                case BlockType.I:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.left);
                    pieces[2].UpdatePosition(spawnPosition + (Vector2Int.right * 2));
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.right);
                    break;

                case BlockType.J:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.left);
                    pieces[2].UpdatePosition(spawnPosition + new Vector2Int(-1, 1));
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.right);
                    break;

                case BlockType.L:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.left);
                    pieces[2].UpdatePosition(spawnPosition + new Vector2Int(1, 1));
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.right);
                    break;

                case BlockType.O:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.right);
                    pieces[2].UpdatePosition(spawnPosition + new Vector2Int(1, 1));
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.up);
                    break;

                case BlockType.S:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.left);
                    pieces[2].UpdatePosition(spawnPosition + new Vector2Int(1, 1));
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.up);
                    break;

                case BlockType.T:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.left);
                    pieces[2].UpdatePosition(spawnPosition + Vector2Int.up);
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.right);
                    break;

                case BlockType.Z:
                    pieces[1].UpdatePosition(spawnPosition + Vector2Int.up);
                    pieces[2].UpdatePosition(spawnPosition + new Vector2Int(-1, 1));
                    pieces[3].UpdatePosition(spawnPosition + Vector2Int.right);
                    break;

                default:

                    break;
            }

            return pieces;
        }

        private void CreateAllBlockOffSets()
        {
            JLSTZ_OFFSET = new Vector2Int[5, 4];
            JLSTZ_OFFSET[0, 0] = Vector2Int.zero;
            JLSTZ_OFFSET[0, 1] = Vector2Int.zero;
            JLSTZ_OFFSET[0, 2] = Vector2Int.zero;
            JLSTZ_OFFSET[0, 3] = Vector2Int.zero;

            JLSTZ_OFFSET[1, 0] = Vector2Int.zero;
            JLSTZ_OFFSET[1, 1] = new Vector2Int(1, 0);
            JLSTZ_OFFSET[1, 2] = Vector2Int.zero;
            JLSTZ_OFFSET[1, 3] = new Vector2Int(-1, 0);

            JLSTZ_OFFSET[2, 0] = Vector2Int.zero;
            JLSTZ_OFFSET[2, 1] = new Vector2Int(1, -1);
            JLSTZ_OFFSET[2, 2] = Vector2Int.zero;
            JLSTZ_OFFSET[2, 3] = new Vector2Int(-1, -1);

            JLSTZ_OFFSET[3, 0] = Vector2Int.zero;
            JLSTZ_OFFSET[3, 1] = new Vector2Int(0, 2);
            JLSTZ_OFFSET[3, 2] = Vector2Int.zero;
            JLSTZ_OFFSET[3, 3] = new Vector2Int(0, 2);

            JLSTZ_OFFSET[4, 0] = Vector2Int.zero;
            JLSTZ_OFFSET[4, 1] = new Vector2Int(1, 2);
            JLSTZ_OFFSET[4, 2] = Vector2Int.zero;
            JLSTZ_OFFSET[4, 3] = new Vector2Int(-1, 2);

            I_OFFSET = new Vector2Int[5, 4];
            I_OFFSET[0, 0] = Vector2Int.zero;
            I_OFFSET[0, 1] = new Vector2Int(-1, 0);
            I_OFFSET[0, 2] = new Vector2Int(-1, 1);
            I_OFFSET[0, 3] = new Vector2Int(0, 1);

            I_OFFSET[1, 0] = new Vector2Int(-1, 0);
            I_OFFSET[1, 1] = Vector2Int.zero;
            I_OFFSET[1, 2] = new Vector2Int(1, 1);
            I_OFFSET[1, 3] = new Vector2Int(0, 1);

            I_OFFSET[2, 0] = new Vector2Int(2, 0);
            I_OFFSET[2, 1] = Vector2Int.zero;
            I_OFFSET[2, 2] = new Vector2Int(-2, 1);
            I_OFFSET[2, 3] = new Vector2Int(0, 1);

            I_OFFSET[3, 0] = new Vector2Int(-1, 0);
            I_OFFSET[3, 1] = new Vector2Int(0, 1);
            I_OFFSET[3, 2] = new Vector2Int(1, 0);
            I_OFFSET[3, 3] = new Vector2Int(0, -1);

            I_OFFSET[4, 0] = new Vector2Int(2, 0);
            I_OFFSET[4, 1] = new Vector2Int(0, -2);
            I_OFFSET[4, 2] = new Vector2Int(-2, 0);
            I_OFFSET[4, 3] = new Vector2Int(0, 2);

            O_OFFSET = new Vector2Int[1, 4];
            O_OFFSET[0, 0] = Vector2Int.zero;
            O_OFFSET[0, 1] = Vector2Int.down;
            O_OFFSET[0, 2] = new Vector2Int(-1, -1);
            O_OFFSET[0, 3] = Vector2Int.left;
        }
    }
}