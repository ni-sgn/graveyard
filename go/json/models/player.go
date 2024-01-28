package models

type Item struct {
	Name string `json:"name"`
	Dmg  int    `json:"damage"`
}

type Player struct {
	Name   string `json:"name"`
	Health int    `json:"health"`
	Items  []Item `json:"items"`
}

func (player *Player) Attack(player2 *Player) {
	player2.Health = player2.Health - player.Items[0].Dmg
}
