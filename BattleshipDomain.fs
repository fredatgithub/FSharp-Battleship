module BattleshipDomain

type Player =
    | Player1
    | Player2

type XCoord = XCoord of int
type YCoord = YCoord of int
type CellCoord = XCoord * YCoord

type ShipType =
    | Carrier
    | Battleship
    | Cruiser
    | Submarine
    | Destroyer

type ShipStatus =
    | Active
    | Sunk

type Ship = { 
    shipType : ShipType
    pos : CellCoord list
    status : ShipStatus
    }

type TargetCellState =
    | Hit of Ship
    | Miss
    | Empty

type TargetCell =  {
    targetCoord : CellCoord
    targetState : TargetCellState
    }

type OceanCellState =
    | Occupied of Ship
    | Empty

type OceanCell = {
    oceanCoord : CellCoord
    oceanState : OceanCellState 
    }

type DisplayBoard = {
    oceanGrid : OceanCell list
    targetGrid : TargetCell list
    }

type MoveCapability = unit -> MoveResult

and NextMoveInfo = {
    cellToPlay : CellCoord
    capability : MoveCapability
    }

and MoveResult =
    | Player1ToMove of DisplayBoard * NextMoveInfo list
    | Player2ToMove of DisplayBoard * NextMoveInfo list
    | GameWon of DisplayBoard * Player

type BattleshipAPI = {
    newGame : MoveCapability
}