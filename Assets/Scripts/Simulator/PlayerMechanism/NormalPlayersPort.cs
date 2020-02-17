﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Simulator {
	public class NormalPlayersPort : IPlayersPort {
		public Func<int> GetNextId { private get; set; }

        private Dictionary<int, IPlayer> idToPlayer;
        private Dictionary<IPlayer, int> playerToId;

        private Dictionary<IPlayer, bool> needsInput;

        public NormalPlayersPort () {
            idToPlayer = new Dictionary<int, IPlayer>();
            playerToId = new Dictionary<IPlayer, int>();
            needsInput = new Dictionary<IPlayer, bool>();
        }

		public void AddPlayer (IPlayer player, bool needsInput) {
			this.needsInput.Add(player, needsInput);
            Debug.Assert(GetNextId != null, $"({this}) GetNextId Func is null");

            int id = GetNextId();
            idToPlayer.Add(id, player);
            playerToId.Add(player, id);
		}

        public void RemovePlayer (int id) {
            if (!idToPlayer.ContainsKey(id)) return;

            var player = idToPlayer[id];
            idToPlayer.Remove(id);
            playerToId.Remove(player);
            needsInput.Remove(player);
        }

		public void HandleMoveResult (List<MoveResult> results) {
			throw new NotImplementedException();
		}

		public List<MoveInfo> MakeMove () {
			throw new System.NotImplementedException();
		}
	}
}